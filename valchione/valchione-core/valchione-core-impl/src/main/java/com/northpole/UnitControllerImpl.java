package com.northpole;

import org.apache.log4j.Logger;

import com.northpole.UnitController;
import com.northpole.util.LoggerConstants;
import com.northpole.dao.UnitDao;
import com.northpole.dao.impl.UnitDaoImpl;
import com.northpole.dto.UnitDto;
import com.northpole.entity.Unit;

public class UnitControllerImpl implements UnitController {
	private UnitDao unitDao;
	private Logger syslog;
	
	public UnitControllerImpl(){
		unitDao= new UnitDaoImpl();
		syslog = Logger.getLogger(LoggerConstants.SYS);
	}
	public UnitDto getUnitInfo(long id){
		syslog.debug("UnitControllerImpl.getUnitInfo - Start");
		Unit unit = unitDao.getById(id);
		
		UnitDto unitDto = null;
		if (unit!=null)
			unitDto = new UnitDto(unit);
		
			
		syslog.debug("UnitControllerImpl.getUnitInfo - End");
		
		return unitDto;
	}
}
