package com.northpole;

import org.apache.log4j.Logger;

import com.northpole.UserController;
import com.northpole.util.LoggerConstants;
import com.northpole.dao.UserDao;
import com.northpole.dao.impl.UserDaoImpl;
import com.northpole.dto.PlayerDto;
import com.northpole.entity.User;

public class UserControllerImpl implements UserController {
	private UserDao userDao;
	private Logger syslog;
	private Logger userlog;
	private final int minPasswordLength = 8;
	private final int maxPasswordLength = 16;

	public UserControllerImpl() {
		userDao = new UserDaoImpl();
		syslog = Logger.getLogger(LoggerConstants.SYS);
		userlog = Logger.getLogger(LoggerConstants.USER);
	}

	public PlayerDto login(String username, String password) {
		syslog.debug("LoginControllerImpl.login - Start");
		syslog.info("Logging In : " + username + "...");
		if (username == null || password == null) {
			syslog.warn("Null username/password...");
			return null;
		}
		User user = userDao.getByUsername(username);

		if (user == null || !password.equals(user.getPassword())) {
			syslog.info("Incorrect username/password...");
			return null;
		}

		PlayerDto playerDto = new PlayerDto(user);

		syslog.info(user.getUsername() + " has logged in.");
		userlog.info(user.getUsername() + " has logged in.");

		syslog.debug("LoginControllerImpl.login - End");
		return playerDto;
	}

	public PlayerDto register(String username, String password) {
		syslog.debug("LoginControllerImpl.register - Start");
		User user;
		if (!passwordLengthGood(password)) {
			System.out.println("Password is not 8-16 chars long...");
			syslog.debug("LoginControllerImpl.register - End");
			return null;
		}

		if (userDao.getByUsername(username) != null) {
			System.out.println("Account already exists...");
			syslog.debug("LoginControllerImpl.register - End");
			return null;
		}

		user = userDao.create(new User(username, password));

	
		if (user == null) {
			syslog.error("Failed to register " + username);
			syslog.debug("LoginControllerImpl.register - End");
			return null;
		}
		
		syslog.info(user.getUsername() + "'s account is successfully created!");
		userlog.info(username + ": Account successfully created!");
		
		PlayerDto playerDto = new PlayerDto(user);

		syslog.debug("LoginControllerImpl.register - End");

		return playerDto;
	}

	private boolean passwordLengthGood(String password) {
		return password.length() >= minPasswordLength || password.length() <= maxPasswordLength;
	}
}
