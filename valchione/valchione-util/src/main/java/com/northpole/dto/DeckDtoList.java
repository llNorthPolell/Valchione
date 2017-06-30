package com.northpole.dto;

import java.util.List;

public class DeckDtoList extends DtoList<DeckDto> {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public DeckDtoList() {
		super();
	}

	public DeckDtoList(List<DeckDto> items) {
		super(items);
	}
	
}
