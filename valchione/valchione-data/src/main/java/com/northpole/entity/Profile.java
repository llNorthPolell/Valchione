package com.northpole.entity;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;


@Entity
@Table(name = "VAL_PROFILE")
public class Profile implements IStorable{
	@Id
	@Column(name="profile_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "profile_id_seq")
	@SequenceGenerator(name="profile_id_seq", sequenceName="VAL_PROFILE_ID_SEQ")
	private long profileId;
	
	@Column(name="player_level")
	private int playerLevel;
	
	@Column(name="player_exp")
	private int playerExp;
	
	@Column(name="coins")
	private int coins;
	
	@Column(name="gems")
	private int gems;
	
	@Column(name="honor_points")
	private int honorPoints;
	
	@Column(name="num_of_decks")
	private int numOfDecks;
	
	@Column(name="story_progress")
	private int storyProgress;
	
	/*@Column(name="last_access_timestamp")
	private Long lastAccess;*/
	
	@OneToMany(mappedBy="profile", cascade = CascadeType.ALL)
	private List<ProfileCard> profileCards = new ArrayList<ProfileCard>();
	
	@OneToMany(mappedBy="profile", cascade = CascadeType.ALL)
	private List<Deck> decks = new ArrayList<Deck>();
	
	public Profile() {
		super();
	}


	public Profile(int playerLevel, int coins, int gems) {
		this();
		this.playerLevel = playerLevel;
		this.coins = coins;
		this.gems = gems;
	}

	public Profile(long profileId, int playerLevel, int coins, int gems) {
		this(playerLevel, coins, gems);
		this.profileId = profileId;
	}


	public long getProfileId() {
		return profileId;
	}


	public void setProfileId(long profileId) {
		this.profileId = profileId;
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


	public int getNumOfDecks() {
		return numOfDecks;
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

	

	public List<ProfileCard> getProfileCards() {
		return profileCards;
	}


	public void setProfileCards(List<ProfileCard> profileCards) {
		this.profileCards = profileCards;
	}


	public List<Deck> getDecks() {
		return decks;
	}


	public void setDecks(List<Deck> decks) {
		this.decks = decks;
	}


	


	@Override
	public String toString() {
		return "Profile [profileId=" + profileId + ", playerLevel=" + playerLevel + ", playerExp=" + playerExp
				+ ", coins=" + coins + ", gems=" + gems + ", honorPoints=" + honorPoints + ", numOfDecks=" + numOfDecks
				+ ", storyProgress=" + storyProgress + "]";
	}


	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + (int) (profileId ^ (profileId >>> 32));
		return result;
	}




	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Profile other = (Profile) obj;
		if (profileId != other.profileId)
			return false;
		return true;
	}

}
