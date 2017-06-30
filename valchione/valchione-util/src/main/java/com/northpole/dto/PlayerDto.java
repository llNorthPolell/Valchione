package com.northpole.dto;

import com.northpole.entity.Profile;
import com.northpole.entity.User;

/**
 * @author NorthPole
 * Stores data about the user and their in game profile.
 */
public class PlayerDto implements Dto{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private String username;
	
	private int playerLevel;
	
	private int playerExp;
	
	private int coins;
	
	private int gems;
	
	private int honorPoints;

	private int numOfDecks;
	
	private int storyProgress;
	
	public PlayerDto() {
		super();
	}

	public PlayerDto(User user){
		super();
		if (user!=null){
			 Profile profile = user.getProfile();
			 username = user.getUsername();
			 playerLevel = profile.getPlayerLevel();
			 playerExp = profile.getPlayerExp();
			 coins = profile.getCoins();
			 gems = profile.getGems();
			 honorPoints = profile.getHonorPoints();
			 numOfDecks = profile.getNumOfDecks();
			 storyProgress = profile.getStoryProgress();
		}
	}
	
	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public int getPlayerLevel() {
		return playerLevel;
	}

	public void setPlayerLevel(int playerLevel) {
		this.playerLevel = playerLevel;
	}

	public int getCoins() {
		return coins;
	}

	public void setCoins(int coins) {
		this.coins = coins;
	}

	public int getGems() {
		return gems;
	}

	public void setGems(int gems) {
		this.gems = gems;
	}

	public int getPlayerExp() {
		return playerExp;
	}

	public void setPlayerExp(int playerExp) {
		this.playerExp = playerExp;
	}

	public int getStoryProgress() {
		return storyProgress;
	}

	public void setStoryProgress(int storyProgress) {
		this.storyProgress = storyProgress;
	}

	public int getHonorPoints() {
		return honorPoints;
	}

	public void setHonorPoints(int honorPoints) {
		this.honorPoints = honorPoints;
	}

	public int getNumOfDecks() {
		return numOfDecks;
	}

	public void setNumOfDecks(int numOfDecks) {
		this.numOfDecks = numOfDecks;
	}
	
}
