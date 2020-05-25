import React from 'react'
import {connect} from "react-redux"
import Card from './Card'
import "./AsideDeck.css"

const AsideDeck = (props) => {
    let items = [];
    for (let item of props.selected)
        items.push(<Card value={item} selected={true}/>);

    return (
        <section className="asideDeck">
            {items}
            <div className="stats"><p><span>{items.length}</span></p></div>
        </section>
    )
};

export default connect(
    state =>
    {
        return{
            sum : state.game.sum,
            turnsLeft : state.game.turnsLeft,
            selected : state.game.selected
        }
    }
)(AsideDeck);