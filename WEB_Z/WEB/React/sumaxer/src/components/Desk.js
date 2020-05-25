import React from 'react'
import Card from './Card'
import {connect} from 'react-redux'
import './Desk.css'

const Desk = (props) => {
    let items = [];
    for (let item of props.board)
        items.push(<Card value={item.value} selected={item.turned}/>);

    return (
        <section className="desk">
            {items}
        </section>
    )
};

export default connect(
    state =>
    {
        return{
            board : state.game.board,
            turnsLeft : state.game.turnsLeft,
            sum : state.game.sum
        }
    }
)(Desk);