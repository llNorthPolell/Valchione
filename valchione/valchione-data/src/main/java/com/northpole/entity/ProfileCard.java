package com.northpole.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

@Entity
@Table(name="VAL_PROFILE_CARD")
@NamedQueries(
		@NamedQuery(name = "profileCard.getAllByProfileId", query = "SELECT pc FROM ProfileCard pc WHERE pc.profile.profileId = :profileId")
		)
public class ProfileCard implements IStorable {
	@Id
	@Column(name="profile_card_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "profile_card_id_seq")
	@SequenceGenerator(name="profile_card_id_seq", sequenceName="VAL_PROFILE_CARD_ID_SEQ")
	private Long profileCardId;
	
	@ManyToOne
	@JoinColumn(name="profile_id")
	private Profile profile;

	@ManyToOne
	@JoinColumn(name="card_id")
	private Card card;

	@Column(name="DECK_CODE")
	private int deckCode;
	
	public ProfileCard() {
		super();
	}



	public Long getProfileCardId() {
		return profileCardId;
	}



	public void setProfileCardId(Long profileCardId) {
		this.profileCardId = profileCardId;
	}



	public Profile getProfile() {
		return profile;
	}



	public void setProfile(Profile profile) {
		this.profile = profile;
	}



	public Card getCard() {
		return card;
	}



	public void setCard(Card card) {
		this.card = card;
	}



	public int getDeckCode() {
		return deckCode;
	}



	public void setDeckCode(int deckCode) {
		this.deckCode = deckCode;
	}



	@Override
	public String toString() {
		return "ProfileCard [profileCardId=" + profileCardId + ", profile=" + profile + ", card=" + card + ", deckCode="
				+ deckCode + "]";
	}



	

	
	
}
