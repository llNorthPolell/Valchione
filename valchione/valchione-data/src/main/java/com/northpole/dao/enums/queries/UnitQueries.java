package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum UnitQueries implements Queries{
	/**
	 * @Param none
	 * @Return All unit information
	 */
	ALL (new NamedQueryNamesDto("unit.getAll"));
	
	private final NamedQueryNamesDto namedQueryNames;
	private UnitQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
