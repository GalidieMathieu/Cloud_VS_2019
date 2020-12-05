import React, { Component } from 'react';

export class Query8 extends Component {
  static displayName = Query8.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
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
                  <td>{forecast.dept[forecast.dept.length-1].dept_no}</td>    
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query8.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('Query8');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
