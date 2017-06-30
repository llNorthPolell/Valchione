package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum TerrainQueries implements Queries{
	/**
	 * @Param terrain name
	 * @Return terrain object
	 */
	BYTERRAINNAME (new NamedQueryNamesDto("terrain.getByTerrainName", "tname"));
	
	private final NamedQueryNamesDto namedQueryNames;
	private TerrainQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
