import React, { useEffect, useState } from "react";
import { Grid } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import MaterialTable from 'material-table';

const useStyles = makeStyles(() => ({
    Grid: {
        height: "88.9vh",
    },
}));

function MatchHistory()
{
    const [matches, setMatches] = useState([]);
    const classes = useStyles();
    
    useEffect( () => {
            fetch("https://localhost:5001/apiMatch/GetMatchHistory", {
                    headers: {"Content-Type": "application/json"},
                    credentials: "include",
                }).then(response => response.json()).then(newMatches => {
                setMatches(newMatches);
                console.log(newMatches);
            })
        }, []);
    
    const columns = [
        {
            title: "Match no.",
            field: "matchId",
            cellStyle: {
                backgroundColor: '#373737',
                color: '#FFF'
            },
            headerStyle: {
                backgroundColor: '#373737',
                color: '#FBB917'
            }
        },
        {
            title: "Result",
            field: "matchState",
            cellStyle: {
                backgroundColor: '#373737',
                color: '#FFF'
            },
            headerStyle: {
                backgroundColor: '#373737',
                color: '#FBB917'
            }
        }
    ]
    
    return (
        <Grid className={classes.Grid}>
            <h1><font color="#FBB917">Your match history</font></h1>
            <MaterialTable 
                columns={columns} 
                data={matches}
                title="Let's see if you're a winner or a loser"
            >
            </MaterialTable>
        </Grid>
    );
}

export default MatchHistory;