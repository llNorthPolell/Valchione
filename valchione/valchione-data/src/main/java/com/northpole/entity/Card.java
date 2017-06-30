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
@Table(name="VAL_CARD")
public class Card implements IStorable {
	@Id
	@Column(name="card_id")
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "card_id_seq")
	@SequenceGenerator(name="card_id_seq", sequenceName="VAL_CARD_ID_SEQ")
	private Long cardId;
	
	@Column(name="card_name")
	private String cardName;
	//private String cardType;
//	private int cost;
	
	
	@OneToMany(mappedBy="card", cascade = CascadeType.ALL)
	private List<ProfileCard> profileCards = new ArrayList<ProfileCard>();
	
	public Card() {
		super();
	}
	
	
	public Card(String cardName) {
		super();
		this.cardName = cardName;
	}


	public Long getCardId() {
		return cardId;
	}
	public void setCardId(Long cardId) {
		this.cardId = cardId;
	}
	public String getCardName() {
		return cardName;
	}
	public void setCardName(String cardName) {
		this.cardName = cardName;
	}
/*	public String getCardType() {
		return cardType;
	}
	public void setCardType(String cardType) {
		this.cardType = cardType;
	}
	public int getCost() {
		return cost;
	}
	public void setCost(int cost) {
		this.cost = cost;
	}*/

	public String toString() {
		return "Card [cardId=" + cardId + ", cardName=" + cardName + "]";
	}


	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((cardId == null) ? 0 : cardId.hashCode());
		return result;
	}


	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Card other = (Card) obj;
		if (cardId == null) {
			if (other.cardId != null)
				return false;
		} else if (!cardId.equals(other.cardId))
			return false;
		return true;
	}
	
	
	
}


