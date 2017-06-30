package com.northpole.dao.impl;

import com.northpole.dao.ProfileCardDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.ProfileCardQueries;
import com.northpole.entity.ProfileCard;

public class ProfileCardDaoImpl extends JPADAOImpl<ProfileCard, ProfileCardQueries> implements ProfileCardDao {
	public ProfileCardDaoImpl() {
		super(ProfileCard.class);
	}

}
