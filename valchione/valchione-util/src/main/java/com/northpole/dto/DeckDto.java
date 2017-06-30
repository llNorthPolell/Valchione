package com.northpole.dto;

import com.northpole.entity.Deck;

public class DeckDto implements Dto{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private int deckIndex;
	private long leaderId;	// profileCardId of the card that is appointed leader
	private String deckName;
	
	
	public DeckDto() {
		super();
	}
	
	public DeckDto(Deck deck){
		super();
		this.deckIndex = deck.getDeckIndex();
		
		this.leaderId = (deck.getLeader()!=null) ? deck.getLeader().getProfileCardId() : 0;
		this.deckName = deck.getName();
	}
	
	public int getDeckIndex() {
		return deckIndex;
	}
	public void setDeckIndex(int deckIndex) {
		this.deckIndex = deckIndex;
	}
	public long getLeaderId() {
		return leaderId;
	}
	public void setLeaderId(long leaderId) {
		this.leaderId = leaderId;
	}
	public String getDeckName() {
		return deckName;
	}
	public void setDeckName(String deckName) {
		this.deckName = deckName;
	}
	
	
	
}
