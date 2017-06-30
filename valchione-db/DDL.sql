/* TABLES */
/* DROP EXISTING TABLES */
DROP TABLE VAL_USER CASCADE CONSTRAINTS;
DROP TABLE VAL_PROFILE CASCADE CONSTRAINTS;
DROP TABLE VAL_TERRAIN CASCADE CONSTRAINTS;
DROP TABLE VAL_UNIT CASCADE CONSTRAINTS;
DROP TABLE VAL_UNIT_TYPE CASCADE CONSTRAINTS;
DROP TABLE VAL_CARD CASCADE CONSTRAINTS;
DROP TABLE VAL_PROFILE_CARD CASCADE CONSTRAINTS;
DROP TABLE VAL_DECK CASCADE CONSTRAINTS;

/* CREATE TABLES */
CREATE TABLE VAL_PROFILE 
(
PROFILE_ID NUMBER(10),
PLAYER_LEVEL NUMBER(4) NOT NULL,
PLAYER_EXP NUMBER(10) NOT NULL,
COINS NUMBER(10) NOT NULL,
GEMS NUMBER(5) NOT NULL,
HONOR_POINTS NUMBER(5) NOT NULL,
NUM_OF_DECKS NUMBER(1) NOT NULL,
STORY_PROGRESS NUMBER(10) NOT NULL,
TIME_OF_CREATION TIMESTAMP NOT NULL,
LAST_ACCESS_TIMESTAMP TIMESTAMP NOT NULL,
PRIMARY KEY (PROFILE_ID)
);

CREATE TABLE VAL_USER
(
  USER_ID NUMBER(10),
  USERNAME VARCHAR(10) NOT NULL,
  PASSWORD VARCHAR(16) NOT NULL,
  PROFILE_ID NUMBER(10),
  PRIMARY KEY (USER_ID),
  CONSTRAINT U_USERNAME UNIQUE (USERNAME),
  CONSTRAINT FK_USER_PROFILE_ID FOREIGN KEY (PROFILE_ID)
  REFERENCES VAL_PROFILE(PROFILE_ID)
);

CREATE TABLE VAL_TERRAIN
(
  TERRAIN_ID NUMBER(10),
  TERRAIN_NAME VARCHAR(10) NOT NULL,
  IS_WALKABLE CHAR(1) NOT NULL,
  PRIMARY KEY (TERRAIN_ID),
  CONSTRAINT U_TERRAIN_NAME UNIQUE (TERRAIN_NAME)
);

CREATE TABLE VAL_UNIT_TYPE
(
  UNIT_TYPE_CODE VARCHAR(4),
  UNIT_TYPE_NAME VARCHAR(16) NOT NULL,
  PRIMARY KEY (UNIT_TYPE_CODE)
);

CREATE TABLE VAL_CARD
(
  CARD_ID NUMBER(10),
  CARD_NAME VARCHAR(16) NOT NULL,
  PRIMARY KEY (CARD_ID),
  CONSTRAINT U_CARD_NAME UNIQUE(CARD_NAME)
);

CREATE TABLE VAL_UNIT
(
  UNIT_ID NUMBER(10),
  UNIT_NAME VARCHAR(16) NOT NULL,
  UNIT_TYPE_CODE VARCHAR(6) NOT NULL,
  UNIT_HP NUMBER(3)NOT NULL,
  UNIT_STR NUMBER(3)NOT NULL,
  UNIT_SPR NUMBER(3)NOT NULL,
  UNIT_AGI NUMBER(3)NOT NULL,
  UNIT_SPD NUMBER(3)NOT NULL,
  PRIMARY KEY (UNIT_ID),
  CONSTRAINT U_UNIT_NAME UNIQUE(UNIT_NAME),
  CONSTRAINT FK_UNIT_UNIT_TYPE_CODE FOREIGN KEY (UNIT_TYPE_CODE)
  REFERENCES VAL_UNIT_TYPE(UNIT_TYPE_CODE)
);


CREATE TABLE VAL_PROFILE_CARD
(
  PROFILE_CARD_ID NUMBER(10) NOT NULL,
  PROFILE_ID NUMBER(10) NOT NULL,
  CARD_ID NUMBER(10) NOT NULL,
  DECK_CODE NUMBER(3) NOT NULL,
  PRIMARY KEY (PROFILE_CARD_ID),
  CONSTRAINT FK_PROFILE_CARD_PROFILE_ID FOREIGN KEY (PROFILE_ID)
  REFERENCES VAL_PROFILE(PROFILE_ID),
  CONSTRAINT FK_PROFILE_CARD_CARD_ID FOREIGN KEY (CARD_ID)
  REFERENCES VAL_CARD(CARD_ID)
);


CREATE TABLE VAL_DECK
(
  DECK_ID NUMBER(10) NOT NULL,
  PROFILE_ID NUMBER(10) NOT NULL,
  DECK_INDEX NUMBER(1) NOT NULL,
  DECK_NAME VARCHAR(16),
  DECK_LEADER_ID NUMBER(10),
  PRIMARY KEY (DECK_ID),
  CONSTRAINT FK_DECK_PROFILE_ID FOREIGN KEY (PROFILE_ID)
  REFERENCES VAL_PROFILE(PROFILE_ID),
  CONSTRAINT FK_DECK_LEADER_ID FOREIGN KEY (DECK_LEADER_ID)
  REFERENCES VAL_PROFILE_CARD(PROFILE_CARD_ID),
  CONSTRAINT U_DECK_INDEX UNIQUE (DECK_INDEX)
);

/* SEQUENCES */
/* DROP EXISTING SEQUENES */
DROP SEQUENCE "NORTHPOLE"."VAL_USER_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_PROFILE_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_TERRAIN_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_UNIT_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_CARD_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_PROFILE_CARD_ID_SEQ";
DROP SEQUENCE "NORTHPOLE"."VAL_DECK_ID_SEQ";

/* CREATE SEQUENCES */
CREATE SEQUENCE  "NORTHPOLE"."VAL_USER_ID_SEQ"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 881 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_PROFILE_ID_SEQ"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 881 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_TERRAIN_ID_SEQ"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 881 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_UNIT_ID_SEQ"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_CARD_ID_SEQ"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_PROFILE_CARD_ID_SEQ" MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "NORTHPOLE"."VAL_DECK_ID_SEQ" MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;