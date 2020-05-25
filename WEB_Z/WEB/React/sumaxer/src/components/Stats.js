import React from 'react'
import {connect} from 'react-redux'
import './Stats.css'

const Stats = (props) => (
    <aside className={props.turnsLeft===0?"stats endGame":"stats"}>
        <p>Tahů do konce: <span>{props.turnsLeft}</span></p>
        <p>Ještě lze vybrat: <span>{props.maxTurned}</span></p>
        <p>Celkem bodů: <span>{props.sum}</span></p>
    </aside>
);

export default connect(
    state =>
    {
        return{
            maxTurned : state.game.maxTurned,
            sum : state.game.sum,
            turnsLeft : state.game.turnsLeft
        }
    }
)(Stats);