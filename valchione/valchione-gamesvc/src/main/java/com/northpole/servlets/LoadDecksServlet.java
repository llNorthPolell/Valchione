package com.northpole.servlets;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;

import com.northpole.dto.DeckDtoList;

/**
 * Servlet implementation class LoadDecksServlet
 */
@WebServlet("/loadDecks")
public class LoadDecksServlet extends BaseServlet<DeckDtoList> {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public LoadDecksServlet() {
        super();
    }

	@Override
	protected DeckDtoList processParams(HttpServletRequest request) {
		String username = request.getParameter("username");
		return coreController.getDecks(username);
	}

	

}
