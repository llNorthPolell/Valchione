package com.northpole.dao.impl;

import java.util.List;


import com.northpole.dao.UnitDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.UnitQueries;
import com.northpole.entity.Unit;

public class UnitDaoImpl extends JPADAOImpl<Unit, UnitQueries> implements UnitDao {
	private static List<Unit> unitCache;
	
	
	public UnitDaoImpl() {
		super(Unit.class);
		unitCache = read(UnitQueries.ALL);
	}

	public List<Unit> getAllUnits() {		
		return unitCache;
	}

}
