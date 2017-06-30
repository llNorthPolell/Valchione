package com.northpole.dao.impl;

import com.northpole.dao.ProfileDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.ProfileQueries;
import com.northpole.entity.Profile;

public class ProfileDaoImpl extends JPADAOImpl<Profile, ProfileQueries> implements ProfileDao {

	protected ProfileDaoImpl() {
		super(Profile.class);
	}

	/*public Profile create(Profile entity) {
		return super.create(entity);
	}

	public Profile update(Profile entity) {
		return super.update(entity);
	}*/

}
