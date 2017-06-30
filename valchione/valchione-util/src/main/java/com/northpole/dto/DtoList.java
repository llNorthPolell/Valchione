package com.northpole.dto;

import java.util.List;

/**
 * Wrapper class for list of dtos to counter incomplete Unity Json Utility
 * @author NorthPole
 *
 * @param <T>
 */
public abstract class DtoList<T extends Dto> implements Dto {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private List<T> items;
	
	public DtoList() {
		super();
	}

	public DtoList(List<T> items) {
		super();
		this.items = items;
	}
	
	public List<T> getItems() {
		return items;
	}

	public void setItems(List<T> items) {
		this.items = items;
	}
	
	@Override
	public String toString() {
		return getClass().toString() + " [items=" + items + "]";
	}
}
