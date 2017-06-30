package com.northpole.dto;

import java.util.List;

/**
 * @author NorthPole
 * Stores data about a list of game units, usually all of them (client loading).
 */
public class UnitDtoList extends DtoList<UnitDto> {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;


	public UnitDtoList() {
		super();
	}


	public UnitDtoList(List<UnitDto> unitDtoItemsList) {
		super(unitDtoItemsList);
	}
	
	
}
