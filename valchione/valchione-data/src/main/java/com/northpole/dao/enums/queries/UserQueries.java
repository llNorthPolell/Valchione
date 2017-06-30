package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum UserQueries implements Queries {
	/**
	 * @Param username
	 * @Return user information with matching username
	 */
	BYUSERNAME (new NamedQueryNamesDto("user.getByUsername", "uname"));
	
	private final NamedQueryNamesDto namedQueryNames;
	private UserQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
