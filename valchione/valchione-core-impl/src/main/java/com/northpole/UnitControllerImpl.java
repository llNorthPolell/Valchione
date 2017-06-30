package com.northpole;

import java.util.ArrayList;
import java.util.List;

import com.northpole.UnitController;
import com.northpole.dao.UnitDao;
import com.northpole.dao.impl.UnitDaoImpl;
import com.northpole.dto.UnitDto;
import com.northpole.dto.UnitDtoList;
import com.northpole.entity.Unit;

public class UnitControllerImpl extends BaseController implements UnitController {
	private UnitDao unitDao;
	
	public UnitControllerImpl(){
		super();
		unitDao= new UnitDaoImpl();
	}
	
	public UnitDto getUnitInfo(Long id){
		syslog.debug("UnitControllerImpl.getUnitInfo - Start");
		Unit unit = unitDao.getById(id);
		
		UnitDto unitDto = null;
		if (unit!=null)
			unitDto = new UnitDto(unit);
		
			
		syslog.debug("UnitControllerImpl.getUnitInfo - End");
		
		return unitDto;
	}
	
	public UnitDtoList getAllUnitInfo() {
		syslog.debug("UnitControllerImpl.getAllUnitInfo - Start");
		List<Unit> unitList = unitDao.getAllUnits();
		
		
		
		
		UnitDtoList unitDtoList = null;
		List<UnitDto> unitDtoItemsList = new ArrayList<>();
		
		if (unitList!=null){		
			for (Unit u : unitList)
				unitDtoItemsList.add(new UnitDto(u));
			
			unitDtoList = new UnitDtoList(unitDtoItemsList);
		}
		
		
		syslog.debug("UnitControllerImpl.getAllUnitInfo - End");
		
		return unitDtoList;
	}
	
	
}
