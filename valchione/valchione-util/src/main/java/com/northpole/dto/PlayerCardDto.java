package com.northpole.dto;

import com.northpole.entity.ProfileCard;

/**
 * @author NorthPole
 * Stores data about cards and decks.
 */
public class PlayerCardDto implements Dto{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private long profileCardId;
	
	private long cardId;

	private int deckCode;
	
	public PlayerCardDto(ProfileCard profileCard) {
		super();
		this.profileCardId = profileCard.getProfileCardId();
		this.cardId = profileCard.getCard().getCardId();
		this.deckCode = profileCard.getDeckCode();
	}

	public int getDeckCode() {
		return deckCode;
	}

	public void setDeckCode(int deckCode) {
		this.deckCode = deckCode;
	}

	public long getProfileCardId() {
		return profileCardId;
	}

	public void setProfileCardId(long profileCardId) {
		this.profileCardId = profileCardId;
	}

	public long getCardId() {
		return cardId;
	}

	public void setCardId(long cardId) {
		this.cardId = cardId;
	}

	
	
}
