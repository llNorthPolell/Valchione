package com.northpole.servlets;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import com.northpole.dto.PlayerDto;

/**
 * Servlet implementation class LoginServlet
 */
@WebServlet("/login")
public class LoginServlet  extends BaseServlet<PlayerDto> {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public LoginServlet() {
		super();
	}



	@Override
	protected PlayerDto processParams(HttpServletRequest request) {
		String username = request.getParameter("username");
		String password = request.getParameter("password");

		return coreController.login(username, password);
	}

}
