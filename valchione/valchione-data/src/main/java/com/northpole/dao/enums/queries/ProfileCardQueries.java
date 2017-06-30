package com.northpole.dao.enums.queries;

import com.northpole.dao.base.NamedQueryNamesDto;

public enum ProfileCardQueries implements Queries {
	/**
	 * @Param profileId
	 * @Return all of the player's cards
	 */
	BYPROFILEID (new NamedQueryNamesDto("profileCard.getAllByProfileId", "profileId"));
	
	private final NamedQueryNamesDto namedQueryNames;
	
	private ProfileCardQueries(NamedQueryNamesDto namedQueryNames){
		this.namedQueryNames = namedQueryNames;
	}

	public NamedQueryNamesDto getNamedQueryNames() {
		return namedQueryNames;
	}
}
