package com.northpole.dao;

import com.northpole.dao.base.IStorage;
import com.northpole.dao.enums.queries.CardQueries;
import com.northpole.entity.Card;

public interface CardDao extends IStorage<Card, CardQueries> {
}
