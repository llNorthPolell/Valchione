package com.northpole.servlets;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import com.northpole.dto.PlayerCardDtoList;

/**
 * Servlet implementation class LoadPlayerCardsServlet
 */
@WebServlet("/loadPlayerCards")
public class LoadPlayerCardsServlet extends BaseServlet<PlayerCardDtoList>{
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public LoadPlayerCardsServlet() {
        super();
    }

	

	@Override
	protected PlayerCardDtoList processParams(HttpServletRequest request) {
		String username = request.getParameter("username");
		return coreController.getPlayerCards(username);
	}

}