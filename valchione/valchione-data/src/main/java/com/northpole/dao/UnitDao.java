package com.northpole.dao;

import java.util.List;

import com.northpole.dao.base.IStorage;
import com.northpole.dao.enums.queries.UnitQueries;
import com.northpole.entity.Unit;

public interface UnitDao extends IStorage<Unit, UnitQueries>{
	public List<Unit> getAllUnits();
}
