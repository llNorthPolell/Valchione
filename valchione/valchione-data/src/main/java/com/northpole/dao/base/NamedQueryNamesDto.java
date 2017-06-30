package com.northpole.dao.base;

public class NamedQueryNamesDto {
	private final String queryName;
	private final String[] params;
	
	public NamedQueryNamesDto(String queryName, String... params) {
		super();
		this.queryName = queryName;
		this.params = params;
	}

	public String getQueryName() {
		return queryName;
	}

	public String[] getParams() {
		return params;
	}
	
	
}
