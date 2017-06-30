package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum CardQueries implements Queries{
	/**
	 * There are no queries for Profile Card.
	 */
	NONE(null);
	
	private final NamedQueryNamesDto namedQueryNames;
	
	private CardQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
