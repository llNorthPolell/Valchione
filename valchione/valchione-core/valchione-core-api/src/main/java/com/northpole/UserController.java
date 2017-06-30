package com.northpole;

import com.northpole.dto.PlayerDto;

public interface UserController extends Controller {

	public PlayerDto login(String username, String password);
	public PlayerDto register(String username, String password);
}
