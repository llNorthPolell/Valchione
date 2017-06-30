package com.northpole.dao.impl;

import com.northpole.dao.TerrainDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.TerrainQueries;
import com.northpole.entity.Terrain;

public class TerrainDaoImpl extends JPADAOImpl<Terrain, TerrainQueries> implements TerrainDao{
	
	protected TerrainDaoImpl() {
		super(Terrain.class);
		
	}
}
