  
import React from 'react';
import {connect} from "react-redux";
import { Form, Button, Alert, FormGroup, Label, Input } from 'reactstrap';
import {fetchPlace} from "../store";

const AddPlace = props => {
    return (
    <>
    {props.error ? (<Alert color="danger">{props.error}</Alert>) : ""}
    <Form inline onSubmit={
        e => {
            let place = e.target[0].value;
            if (place !== "") {
                props.fetchPlace(place);
            }
            e.preventDefault();
        }
    }>
        <FormGroup>
          <Label for="exampleEmail">Místo: </Label>
          <Input type="text" name="place" id="place" placeholder="Liberec" />
        </FormGroup>
        <Button color="primary">Add</Button>
    </Form>
    </>
    );
}

export default connect(state => {return {error: state.error}}, {fetchPlace: fetchPlace})(AddPlace);