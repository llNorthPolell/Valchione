package com.northpole.entity;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="VAL_DECK")
@NamedQueries({
	@NamedQuery(name = "deck.getAll", query = "SELECT d FROM Deck d")
})
public class Deck implements IStorable {
	@Id
	@Column(name="deck_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "deck_id_seq")
	@SequenceGenerator(name="deck_id_seq", sequenceName="VAL_DECK_ID_SEQ")
	private Long deckId;
	
	@Column(name = "deck_name")
	private String name;
	
	@Column(name = "deck_index")
	private int deckIndex;
	
	@ManyToOne
	@JoinColumn(name="profile_id")
	private Profile profile;
	
	@OneToOne(cascade=CascadeType.ALL,fetch = FetchType.LAZY)
	@JoinColumn(name="deck_leader_id")
	private ProfileCard leader;
	
	
	
	public Deck() {
		super();
	} 
	
	
	public Deck(Profile profile, String name, ProfileCard leader) {
		super();
		this.profile = profile;
		this.name = name;
		this.leader = leader;
	}


	public Long getDeckId() {
		return deckId;
	}
	public void setDeckId(Long deckId) {
		this.deckId = deckId;
	}
	public Profile getProfile() {
		return profile;
	}
	public void setProfile(Profile profile) {
		this.profile = profile;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public ProfileCard getLeader() {
		return leader;
	}
	public void setLeader(ProfileCard leader) {
		this.leader = leader;
	}

	public int getDeckIndex() {
		return deckIndex;
	}

	public void setDeckIndex(int deckIndex) {
		this.deckIndex = deckIndex;
	}


	@Override
	public String toString() {
		return "Deck [deckId=" + deckId + ", name=" + name + ", deckIndex=" + deckIndex + ", profile=" + profile.getProfileId()
				+ ", leader=" + leader + "]";
	}
	
	
	
	
}
