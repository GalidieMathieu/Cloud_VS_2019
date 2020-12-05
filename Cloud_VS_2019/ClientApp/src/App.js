import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Query1 } from './components/Query1';
import { Query2 } from './components/Query2';
import { Query3 } from './components/Query3';
import { Query4 } from './components/Query4';
import { Query5 } from './components/Query5';
import { Query6 } from './components/Query6';
import { Query7 } from './components/Query7';
import { Query8 } from './components/Query8';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/1_query' component={Query1} />
            <Route path='/2_query' component={Query2} />
            <Route path='/3_query' component={Query3} />
            <Route path='/4_query' component={Query4} />
            <Route path='/5_query' component={Query5} />
            <Route path='/6_query' component={Query6} />
            <Route path='/7_query' component={Query7} />
            <Route path='/8_query' component={Query8} />
      </Layout>
    );
  }
}
