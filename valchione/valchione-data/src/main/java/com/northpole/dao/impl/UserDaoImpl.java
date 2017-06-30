package com.northpole.dao.impl;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.northpole.dao.UserDao;
import com.northpole.dao.base.JPADAOImpl;
import com.northpole.dao.enums.queries.UserQueries;
import com.northpole.entity.User;

public class UserDaoImpl extends JPADAOImpl<User, UserQueries> implements UserDao {
	private static Map<String, User> userCache= new HashMap<>();
	
	public UserDaoImpl(){
		super(User.class);
	}
	
	public User getByUsername(String username) {
		User returnedUser = userCache.get(username);
		
		if (returnedUser==null){
			List<User> returnedUsers = read(UserQueries.BYUSERNAME,username);
			
			if (returnedUsers.isEmpty())
				return null;
			
			returnedUser = returnedUsers.get(0);
			
			if (returnedUser!=null)
				userCache.put(username, returnedUser);
		}
		
		return returnedUser;
	}
	
	
}
