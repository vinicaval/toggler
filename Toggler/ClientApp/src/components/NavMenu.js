import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>Toggler</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/features'} exact>
              <NavItem>
                <Glyphicon glyph='education' /> Features
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/features/new'}>
                <NavItem>
                    <Glyphicon glyph='list-alt' /> Create new Feature
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/applications'} exact>
              <NavItem>
                <Glyphicon glyph='th-list' /> Applications
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/applications/new'}>
              <NavItem>
                <Glyphicon glyph='list-alt' /> Create new Application
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
