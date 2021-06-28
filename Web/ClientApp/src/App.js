import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { AutomobilesList } from './components/AutomobilesList';
import { AutomobileEditor } from './components/AutomobileEditor';
import { ModelsList } from './components/ModelsList';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={AutomobilesList} />
        <Route path='/editCar/:carId' component={AutomobileEditor} />
        <Route path='/models' component={ModelsList} />
      </Layout>
    );
  }
}
