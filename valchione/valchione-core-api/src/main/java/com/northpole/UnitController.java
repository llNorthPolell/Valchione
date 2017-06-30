package com.northpole;

import com.northpole.dto.UnitDto;
import com.northpole.dto.UnitDtoList;

public interface UnitController extends Controller{
	public UnitDto getUnitInfo(Long id);
	public UnitDtoList getAllUnitInfo();
}
