import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { ContactUsForm } from './components/ContactUsForm';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={ContactUsForm} />
      </Layout>
    );
  }
}
