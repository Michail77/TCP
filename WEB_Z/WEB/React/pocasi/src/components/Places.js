  
import React from 'react';
import {connect} from "react-redux";
import { Table, Spinner } from 'reactstrap';
import {fetchPlace} from "../store";

const Places = props => {
    if (props.busy)
    {
        return <div className="text-center"><Spinner /></div>;   
    }
    if (props.places.length === 0)
    {
        return <p>There are no places at this moment.</p>
    }
    else
    {
        return (
            <Table striped hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Weather</th>
                        <th>Temperature</th>
                        <th>Humidity</th>
                    </tr>
                </thead>
                <tbody>
                    {props.places.map((item,index) => (
                        <tr key={index}>
                            <td>{item.name}</td>
                            <td>{item.weather[0].description}</td>
                            <td>{item.main.temp}&#x2103;</td>
                            <td>{item.main.humidity}%</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        )      
    }    
}

export default connect(state => {return {places: state.places, busy: state.busy}}, {fetchPlace: fetchPlace})(Places);