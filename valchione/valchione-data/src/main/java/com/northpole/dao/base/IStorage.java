package com.northpole.dao.base;

import java.util.List;

import com.northpole.dao.enums.WriteAction;
import com.northpole.dao.enums.queries.Queries;
import com.northpole.entity.IStorable;

public interface IStorage<T extends IStorable, Q extends Queries> {
/*	public T create(T entity);
	public T update(T entity);
	public T getById(Long id);
	public boolean delete(T entity);*/
	
	T write(WriteAction writeAction, T entity);
	List<T> read(Q query, Object...args);
	T getById(Long id);
}
