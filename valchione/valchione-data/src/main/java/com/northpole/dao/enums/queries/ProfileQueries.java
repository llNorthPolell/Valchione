package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum ProfileQueries implements Queries{
	/**
	 * There are no queries for Profile.
	 */
	NONE(null);
	
	private final NamedQueryNamesDto namedQueryNames;
	
	private ProfileQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
