import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Application } from './components/Application';
import { Feature } from './components/Feature';
import { NewFeature } from './components/NewFeature';
import { NewApplication } from './components/NewApplication';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/features' component={Feature} />
        <Route exact path='/applications' component={Application} />
        <Route path='/features/new' component={NewFeature} />
        <Route path='/applications/new' component={NewApplication} />
      </Layout>
    );
  }
}
