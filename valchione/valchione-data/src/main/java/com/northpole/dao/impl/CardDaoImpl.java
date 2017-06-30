package com.northpole.dao.impl;

import com.northpole.dao.CardDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.CardQueries;
import com.northpole.entity.Card;

public class CardDaoImpl extends JPADAOImpl<Card, CardQueries> implements CardDao {

	public CardDaoImpl() {
		super(Card.class);
	}

	/*public Card create(Card entity) {
		return super.create(entity);
	}

	public Card update(Card entity) {
		return super.update(entity);
	}
*/

}
