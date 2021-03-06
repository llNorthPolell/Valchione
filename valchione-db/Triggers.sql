CREATE OR REPLACE TRIGGER 
  VAL_PROFILE_CREATE_TRIGGER
AFTER INSERT ON 
  VAL_PROFILE
FOR EACH ROW
BEGIN 
  FOR i IN 1..3 LOOP
    INSERT INTO VAL_DECK (DECK_ID, PROFILE_ID, DECK_INDEX, DECK_NAME, DECK_LEADER_ID)
    VALUES (VAL_DECK_ID_SEQ.nextVal, :NEW.PROFILE_ID, i , 'Deck '||i, null);
  END LOOP;
END;
/