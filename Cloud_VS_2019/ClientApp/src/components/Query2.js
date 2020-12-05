import React, { Component } from 'react';

export class Query2 extends Component {
  static displayName = Query2.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateQuery2Data();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>first name</th>
            <th>last name</th>
            <th>dept</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.iD}>
                  <td>{forecast.first_name}</td>
                  <td>{forecast.last_name}</td>
                  <td>d005</td>    
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query2.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query 2</h1>
            <p>personnes travaillant actuellement dans un departement donne</p>
        {contents}
      </div>
    );
  }

    async populateQuery2Data() {
    const response = await fetch('Query2');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
