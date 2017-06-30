package com.northpole;

import com.northpole.dto.UnitDto;

public interface UnitController extends Controller{
	public UnitDto getUnitInfo(long id);
}
