package com.northpole.dao;

import com.northpole.dao.base.IStorage;
import com.northpole.dao.enums.queries.UserQueries;
import com.northpole.entity.User;

public interface UserDao extends IStorage<User, UserQueries>{
	public User getByUsername(String username);
	
}
