import React from 'react'
import {connect} from 'react-redux'
import {actionCreators} from '../store/Game'
import './Card.css'

const Card = (props) => (
    <figure className={props.selected ? "item selected" : "item"} onClick={()=>{props.turnCard(props.value);}}>
        <div className="face"><p>{props.value}</p></div>
        <div className="back"><div className="yin-yang"/><p>SUMAxer</p></div>
    </figure>
);

export default connect(
    state =>
    {
        return{}
    },
    {
        turnCard : actionCreators.turnCard
    }
)(Card);