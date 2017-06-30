package com.northpole.dao;

import com.northpole.dao.base.IStorage;
import com.northpole.dao.enums.queries.TerrainQueries;
import com.northpole.entity.Terrain;

public interface TerrainDao extends IStorage<Terrain, TerrainQueries>{
	//public Terrain getByTerrainName(String terrainName);
}
