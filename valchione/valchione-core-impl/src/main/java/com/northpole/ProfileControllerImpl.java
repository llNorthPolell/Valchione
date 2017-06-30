package com.northpole;

import java.util.ArrayList;
import java.util.List;

import com.northpole.dao.UserDao;
import com.northpole.dao.impl.UserDaoImpl;
import com.northpole.dto.DeckDto;
import com.northpole.dto.DeckDtoList;
import com.northpole.dto.PlayerCardDto;
import com.northpole.dto.PlayerCardDtoList;
import com.northpole.entity.Deck;
import com.northpole.entity.Profile;
import com.northpole.entity.ProfileCard;
import com.northpole.entity.User;

public class ProfileControllerImpl extends BaseController implements ProfileController{
	private UserDao userDao;
	
	public ProfileControllerImpl(){
		userDao = new UserDaoImpl();
	}
	
	public PlayerCardDtoList getPlayerCards(String username){
		User returnedUser = userDao.getByUsername(username);
		
		List<ProfileCard> profileCards = returnedUser.getProfile().getProfileCards();
		List<PlayerCardDto> dtoItemList = new ArrayList<>();
		
		
		for (ProfileCard p : profileCards)
			dtoItemList.add(new PlayerCardDto(p));
		return new PlayerCardDtoList(dtoItemList);
	}
	

	public Profile updateLastAccess(Profile profile) {
		//TODO: Update Last Access Timestamp
		return null;
	}

	@Override
	public DeckDtoList getDecks(String username) {
		User returnedUser = userDao.getByUsername(username);
		
		List<Deck> decks = returnedUser.getProfile().getDecks();
		List<DeckDto> dtoItemList = new ArrayList<>();
		
		
		for (Deck d : decks)
			dtoItemList.add(new DeckDto(d));
		return new DeckDtoList(dtoItemList);
	}

}
