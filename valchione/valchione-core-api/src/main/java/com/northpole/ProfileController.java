package com.northpole;

import com.northpole.dto.DeckDtoList;
import com.northpole.dto.PlayerCardDtoList;
import com.northpole.entity.Profile;

public interface ProfileController extends Controller {
	public PlayerCardDtoList getPlayerCards(String username);
	public Profile updateLastAccess(Profile profile);
	public DeckDtoList getDecks(String username);
}
