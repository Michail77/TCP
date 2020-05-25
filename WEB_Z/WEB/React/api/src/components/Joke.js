import React from 'react';
import {connect} from "react-redux";
import {FetchCategories, FetchJoke} from "../store";
import {Spinner,Alert,Input,FormGroup,Button,Form,Container} from "reactstrap";

class Joke extends React.Component{
    constructor(props){
        props.FetchCategories();
        super(props);
    }

    render() {
        let listItems = [];
        if (this.props.categories)
        listItems = this.props.categories.map((number) =>
            <option>{number}</option>
        );
        if (this.props.error)
            return <Alert color="danger">Chyba</Alert>;
        else if (this.props.busy)
            return<Container><Spinner/></Container>;
        return (
            <Container>
                <p>{this.props.joke}</p>
                <Form onSubmit={e=>{e.preventDefault();this.props.FetchJoke(e.target[0].value);}}>
                    <FormGroup>
                        <Input type="select" name="category" defaultValue={this.props.category}>
                            {listItems}
                        </Input>
                        <Button color="primary">Random joke</Button>
                    </FormGroup>
                </Form>
            </Container>
        );
    }
}

export default connect(state => {return {joke: state.joke,busy: state.busy,error:state.error,categories: state.categories,category:state.category}}, {FetchJoke: FetchJoke,FetchCategories:FetchCategories})(Joke);