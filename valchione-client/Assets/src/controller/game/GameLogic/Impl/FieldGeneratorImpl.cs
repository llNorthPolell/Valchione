using UnityEngine;
using System.Collections.Generic;
using System;

public class FieldGeneratorImpl: FieldGenerator {
    private MissionDto missionDto;
    private Dictionary<int, string> tilesUsed;
    private TileCache tileCache;
    private GameObject playingFieldGameObject;

    public FieldGeneratorImpl(MissionDto missionDto)
    {
        tileCache = TileCache.getInstance();
        tilesUsed = new Dictionary<int, string>();
        this.missionDto = missionDto;

        createPlayingField();
        loadTiles();
    }

    private void createPlayingField()
    {
        playingFieldGameObject = new GameObject("PlayingField");
        playingFieldGameObject.transform.position = Vector3.zero;
    }

    public void generateMap()
    {
        String[] buffer = missionDto.tiles.Split('+');
        Dictionary<Vector2, GameObject> playingField = new Dictionary<Vector2, GameObject>();
        int x = 0;
        int y = 0;
        int z = 0;

        foreach (String layer in buffer)
        {
            String[] gidList = JsonStringUtil.jsonListStringToStringArray(layer);

            foreach (String gidString in gidList)
            {
                int gid = 0;
                GameObject tile = null;

                if (int.TryParse(gidString, out gid))
                    tile = (gid != 0) ? tileCache.generateTile(tilesUsed[gid]) : null;

                if (tile != null)
                {
                    Vector3 position = new Vector3(x, y, z);
                    
                    tile.transform.SetParent(playingFieldGameObject.transform);
                    tile.name = VectorUtil.convertVect3To2(position).ToString();

                    tile.transform.position = position;
                    playingField[VectorUtil.convertVect3To2(position)] = tile;
                }

                x++;
                if (x == missionDto.width)
                {
                    x = 0;
                    z--;
                }
            }
            x = 0;
            z = 0;
            y++;
        }

        FieldDto fieldDto = new FieldDto();
        fieldDto.playingField = playingField;
        FieldControllerImpl.loadMap(fieldDto);
    }
    

    private void loadTiles()
    {
        String[] gidBuf = missionDto.gids.Split(',');
        String[] tileNameBuf = missionDto.tileNames.Split(',');

        
        if (gidBuf.Length != tileNameBuf.Length)
            return;

        for (int i = 0; i < gidBuf.Length; i++)
        {
            int gid = 0;

            if (int.TryParse(gidBuf[i], out gid))
                tilesUsed[gid] = tileNameBuf[i].ToLower();

        }
    }
}
