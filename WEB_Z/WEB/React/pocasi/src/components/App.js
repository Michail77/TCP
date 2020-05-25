import React from 'react';
import {Navbar, NavbarBrand, DropdownItem, UncontrolledDropdown, DropdownToggle, DropdownMenu, NavItem, NavLink, Nav} from "reactstrap";
import {connect} from "react-redux";
import {fetchPlace} from "../store";
import './App.css';
import Places from "./Places";
import AddPlace from "./AddPlace";

function App(props) {
  return (
    <>
      <Navbar color="light" fixed="top" light={true} expand="md">
        <NavbarBrand href="/">Weather</NavbarBrand>
        <Nav navbar>
          <NavItem>
            <NavLink href="https://openweathermap.org/api">API</NavLink>
          </NavItem>
          <UncontrolledDropdown nav inNavbar>
            <DropdownToggle nav caret>Add Place</DropdownToggle>
                <DropdownMenu>
                  <DropdownItem onClick={e=>{props.fetchPlace("Liberec")}}>Liberec</DropdownItem>
                  <DropdownItem onClick={e=>{props.fetchPlace("Jablonec nad Nisou")}}>Jablonec nad Nisou</DropdownItem>
                  <DropdownItem onClick={e=>{props.fetchPlace("Praha")}}>Praha</DropdownItem>
                  <DropdownItem onClick={e=>{props.fetchPlace("Brno")}}>Brno</DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem onClick={e=>{props.fetchPlace("London")}}>London</DropdownItem>
                  <DropdownItem onClick={e=>{props.fetchPlace("Paris")}}>Paris</DropdownItem>
                  <DropdownItem onClick={e=>{props.fetchPlace("New York")}}>New York</DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem onClick={e=>{props.fetchPlace("Olympus Mons")}}>Olympus Mons</DropdownItem>
                </DropdownMenu>
          </UncontrolledDropdown>
        </Nav>
      </Navbar>
      <main className="container">
        <AddPlace />
        <Places />
      </main>
      <footer id="sticky-footer" className="py-4 bg-dark text-white-50  fixed-bottom">
        <div className="container text-center">
          <small>OpenWeatherMap API Demo</small>
        </div>
      </footer>
    </>
  );
}

export default connect(state => {return {error: state.error}}, {fetchPlace: fetchPlace})(App);